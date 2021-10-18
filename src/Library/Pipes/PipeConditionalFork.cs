using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;


namespace CompAndDel.Pipes
{
    public class PipeConditionalFork : IPipe
    {
        private IPipe falsePipe;
        private IPipe truePipe;
        private IConditionalFilter filter;
        
        /// <summary>
        /// La cañería recibe una imagen, la clona y envìa la original por una cañeria y la clonada por otra.
        /// </summary>
        /// <param name="nextPipe">Cañería con filtro si el filtro retorna true</param>
        /// <param name="next2Pipe">Cañería con filtro si el filtro retorna true</param>
        /// <param name="filter">Filtro condicional que se aplica sobre la imagen y se evalúa posteriormente.</param>
        public PipeConditionalFork(IPipe truePipe, IPipe falsePipe, IConditionalFilter filter)
        {      
            this.filter = filter;
            this.truePipe = truePipe;
            this.falsePipe = falsePipe;
        }
        
        /// <summary>
        /// La cañería recibe una imagen, evalúa el filtro y, según su resultado,
        /// envía la imagen por una de las dos cañerías.
        /// </summary>
        /// <param name="picture">imagen a filtrar y enviar a las siguientes cañerías</param>
        public IPicture Send(IPicture picture)
        {
            this.filter.Filter(picture);
            if(this.filter.Result){
                return this.truePipe.Send(picture);
            } else {
                return this.falsePipe.Send(picture);
            }
        }
    }
}
