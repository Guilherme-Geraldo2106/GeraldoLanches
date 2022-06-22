using GeraldoLanches.Context;
using Microsoft.EntityFrameworkCore;

namespace GeraldoLanches.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext_context _context;
        
        public CarrinhoCompra (AppDbContext_context Context) 
        {
            _context = Context;
        }

        public string CarrinhoCompraId { get; set; }
        public List <CarrinhoCompraItem> carrinhoCompraItens { get; set; }


        //Configuração Http
        public static CarrinhoCompra GetCarrinho(IServiceProvider services) 
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext_context>();

            string carrinhoId = session.GetString("CarrinhoId")??Guid.NewGuid().ToString();

            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        //Método para Adicionar item ao carrinho 
        public void AddAoCarrinho(Lanche lanche) 
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(s=> s.Lanche.LancheId == lanche.LancheId && s.CarrinhoCompraId == CarrinhoCompraId);
            
            if (carrinhoCompraItem == null) 
            {
                carrinhoCompraItem = new CarrinhoCompraItem 
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1,
                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }

            _context.SaveChanges();
        }

        //Método para remover item do carrinho
        public void RemoverDoCarrinho(Lanche lanche) 
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(s => s.Lanche.LancheId == lanche.LancheId && s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem.Quantidade > 1)
            {
                carrinhoCompraItem.Quantidade--;
            }
            else 
            {
                _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
            }

            _context.SaveChanges();
            
        }

        //Listar carrinho
        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return carrinhoCompraItens ?? (carrinhoCompraItens = _context.CarrinhoCompraItens
                                                                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                                                                .Include(s => s.Lanche)
                                                                .ToList());
        }


        //Limpar Carrinho
        public void LimparCarrinho() 
        {
            var carrinhoCompra = _context.CarrinhoCompraItens
                                 .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

            _context.CarrinhoCompraItens.RemoveRange(carrinhoCompra);
            _context.SaveChanges();
        }


        //Valor total do carrinho 
        public decimal GetValorTotal() 
        {
            var valortotal = _context.CarrinhoCompraItens
                             .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                             .Select(c => c.Quantidade * c.Lanche.Preco).Sum();

            return valortotal;  
        }



    }
}
