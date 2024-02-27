namespace CPW219_eCommerceSite.Models
{
    public class MenuCatalogViewModel
    {
        public MenuCatalogViewModel(List<MenuItem> items, int lastPage, int currentPage)
        {
            MenuItems = items;
            LastPage = lastPage;
            CurrentPage = currentPage;
        }

        public List<MenuItem> MenuItems { get; private set; }

        /// <summary>
        /// Last page of the catalog, calculated by having a total number of products
        /// divided by products por page
        /// </summary>
        public int LastPage { get; private set; }

        /// <summary>
        /// Page being viewed by the user at the moment
        /// </summary>
        public int CurrentPage { get; private set; }
    }
}
