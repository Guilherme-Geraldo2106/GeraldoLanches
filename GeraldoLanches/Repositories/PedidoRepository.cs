using GeraldoLanches.Context;
using GeraldoLanches.Models;
using GeraldoLanches.Repositories.Interfaces;

namespace GeraldoLanches.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext_context _context;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext_context context, CarrinhoCompra carrinhoCompra)
        {
            _context = context;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            var carrinhocompraItens = _carrinhoCompra.carrinhoCompraItens;

            foreach (var carrinhoItem in carrinhocompraItens)
            {
                var pedidoDetail = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    LancheId = carrinhoItem.Lanche.LancheId,
                    PedidoId = pedido.PedidoId,
                    Preco = carrinhoItem.Lanche.Preco

                };

                _context.PedidoDetalhes.Add(pedidoDetail);
            }
            _context.SaveChanges();
        }
    }
}
