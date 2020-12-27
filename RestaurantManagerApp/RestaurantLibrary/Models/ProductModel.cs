namespace RestaurantLibrary.Models
{
    public class ProductModel
    {
        /// <summary>
        /// Represents unique identifier of product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represent the product's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represent the available portion count of product.
        /// </summary>
        public int PortionCount { get; set; }

        /// <summary>
        /// Represents the measure units of product.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Represents the portion size of product.
        /// </summary>
        public double PortionSize { get; set; }

        /// <summary>
        /// Represents ProductModel object.
        /// </summary>
        public string DisplayName {
            get 
            {
                return string.Format("{0,-4}{1,-16}{2,-4}{3,-10}{4,-5}", Id.ToString(), Name, PortionCount.ToString(), Unit, PortionSize.ToString());
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ProductModel() { }

        /// <summary>
        /// Creates object with initialized values.
        /// </summary>
        /// <param name="productName">Product's name.</param>
        /// <param name="portionCount">Product's portion count.</param>
        /// <param name="unit">Product's unit.</param>
        /// <param name="portionSize">Product's portion size.</param>
        public ProductModel(string productName, string portionCount, string unit, string portionSize)
        {
            Name = productName;

            int portionCountValue = int.Parse(portionCount);
            PortionCount = portionCountValue;

            Unit = unit;

            double portionSizeValue = double.Parse(portionSize);
            PortionSize = portionSizeValue;
        }
    }
}
