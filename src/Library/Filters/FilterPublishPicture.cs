using System;
using TwitterUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe, procesa y retorna imágenes. El filtro puede retornar la misma imagen o una nueva imagen
    /// creada por él.
    /// </remarks>
    public class FilterPublishPicture : IFilter
    {        

        private string post;
        private string path;

        public FilterPublishPicture(string post, string path){
            this.post = post;
            this.path = path;
        }

        /// <summary>
        /// Un filtro utilizado para publicar la imagen en Twitter durante o después del proceso de modificación.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La misma imagen o una nueva imagen creada por el filtro.</returns>
        public IPicture Filter(IPicture image){
            TwitterImage twitterImage = new TwitterImage();
            System.Console.WriteLine(twitterImage.PublishToTwitter(this.post, this.path));
            return image;
        }
    }
}
