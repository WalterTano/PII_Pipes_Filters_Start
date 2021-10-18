using System;
using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe, procesa y retorna imágenes. El filtro puede retornar la misma imagen o una nueva imagen
    /// creada por él.
    /// </remarks>
    public class FilterFaceRecognition : IConditionalFilter
    {
        private string path;
        public bool Result { get; private set; }

        public FilterFaceRecognition(string path){
            this.path = path;
            this.Result = false;
        }

        /// <summary>
        /// Un filtro utilizado para identificar rostros en una imagen.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La misma imagen o una nueva imagen creada por el filtro.</returns>
        public IPicture Filter(IPicture image){
            CognitiveFace faceAPI = new CognitiveFace();
            faceAPI.Recognize(this.path);
            this.Result = faceAPI.FaceFound;
            return image;
        }
    }
}
