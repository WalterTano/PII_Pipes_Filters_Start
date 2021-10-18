using System;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe, procesa y retorna imágenes. El filtro puede retornar la misma imagen o una nueva imagen
    /// creada por él.
    /// </remarks>
    public class FilterSavePicture : IFilter
    {
        private PictureProvider provider = new PictureProvider();
        private string path;

        public FilterSavePicture(string path){
            this.path = path;
        }

        /// <summary>
        /// Un filtro utilizado para guardar la imagen durante el proceso de modificación.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La misma imagen o una nueva imagen creada por el filtro.</returns>
        public IPicture Filter(IPicture image){
            this.provider.SavePicture(image, this.path);
            return image;
        }
    }
}
