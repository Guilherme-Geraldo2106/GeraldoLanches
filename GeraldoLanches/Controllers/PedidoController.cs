using GeraldoLanches.Models;
using GeraldoLanches.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeraldoLanches.Controllers
{
    [Authorize]
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            int totalCarrinhoItens = 0;
            decimal valortotalCarrinhoCompra = 0;

            List<CarrinhoCompraItem> Itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.carrinhoCompraItens = Itens;

            if(_carrinhoCompra.carrinhoCompraItens.Count == 0) 
            {
                ModelState.AddModelError("", "Erro, seu carrinha precisa conter ao menos um item para continuar");
            }

            foreach (var item in Itens)
            {
                totalCarrinhoItens += item.Quantidade;
                valortotalCarrinhoCompra += (item.Lanche.Preco * item.Quantidade);
            }

            pedido.TotalItensPedido = totalCarrinhoItens;
            pedido.PedidoTotal = valortotalCarrinhoCompra;

            if (ModelState.IsValid)
            {
               
                _pedidoRepository.CriarPedido(pedido);
              
                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido :)";
                ViewBag.TotalPedido = _carrinhoCompra.GetValorTotal();
               
                _carrinhoCompra.LimparCarrinho();

                return View("CheckoutCompleto", pedido);
            }

            return View(pedido);
        }

    }
}
