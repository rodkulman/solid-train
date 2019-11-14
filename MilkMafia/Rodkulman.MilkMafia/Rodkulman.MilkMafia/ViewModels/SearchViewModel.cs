using MvvmHelpers;
using Rodkulman.MilkMafia.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Rodkulman.MilkMafia.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private string searchText;
        private ObservableRangeCollection<Product> products = new ObservableRangeCollection<Product>();
        private IEnumerable<Product> allProducts;
        private Command searchCommand;

        public ObservableRangeCollection<Product> Products
        {
            get { return products; }
            set { SetProperty(ref products, value); }
        }

        public string SearchText
        {
            get { return searchText; }
            set { SetProperty(ref searchText, value); }
        }

        public Command SearchCommand => searchCommand ?? (searchCommand = new Command(FilterProducts));

        public SearchViewModel()
        {
            allProducts = (Application.Current as App).Categories.SelectMany(x => x.Products).ToList();
        }

        public async void FilterProducts()
        {
            this.IsBusy = true;

            await Task.Run(() =>
            {
                for (int i = Products.Count - 1; i >= 0; i--)
                {
                    products.RemoveAt(i);
                }

                products.AddRange(allProducts.Where(FilterProduct));
            });

            this.IsBusy = false;
        }

        private bool FilterProduct(Product product)
        {
            var sanitazedName = RemoveDiacritics(product.Description);
            var sanitazedSearchText = RemoveDiacritics(searchText);

            var seachWords = Regex.Split(sanitazedSearchText, @"\b[a-zA-Z0-9]+?\b");
            var nameWords = Regex.Split(sanitazedName, @"\b[a-zA-Z0-9]+?\b");

            return nameWords.Any(x =>
            {
                return seachWords.Contains(x, StringComparer.OrdinalIgnoreCase);
            });
        }

        public string RemoveDiacritics(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) { return string.Empty; }

            var normalized = str.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            for (int i = 0; i < normalized.Length; i++)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(normalized[i]) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(normalized[i]);
                }
            }

            return sb.ToString();
        }
    }
}
