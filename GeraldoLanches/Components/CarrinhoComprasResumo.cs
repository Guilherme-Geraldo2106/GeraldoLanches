using GeraldoLanches.Models;
using GeraldoLanches.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GeraldoLanches.Components
{
    public class CarrinhoComprasResumo : ViewComponent
    {
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoComprasResumo(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }

        public IViewComponentResult Invoke() 
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.carrinhoCompraItens = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                ValorTotalCarrinho = _carrinhoCompra.GetValorTotal()
            };

            return View(carrinhoCompraVM);
        }
    }
}
