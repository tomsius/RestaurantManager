namespace RestaurantLibrary
{
    public class ProductModel
    {
        /// <summary>
        /// Represents unique identifier of product
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represent the product's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represent the available portion count of product
        /// </summary>
        public int PortionCount { get; set; }

        /// <summary>
        /// Represents the measure units of product
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Represents the portion size of product
        /// </summary>
        public double PortionSize { get; set; }
    }
}
