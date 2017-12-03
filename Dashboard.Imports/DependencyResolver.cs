using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Dashboard.Imports
{
    public class DependencyResolver
    {
        private static DependencyResolver instance;

        private DependencyResolver(){}

        public static DependencyResolver Instance
        {
            get
            {
                if (instance == null)
                    instance = new DependencyResolver();
                return instance;
            }
        }

        private void ResolveAll()
        {
            IUnityContainer unityContainer = new UnityContainer();
            //unityContainer.RegisterInstance<>
        }
    }
}
