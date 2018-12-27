//using DealOrNoDealTwo.Data;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Unity;
//using Unity.Injection;

//namespace DealOrNoDealTwo.Domain
//{
//    public static class DIContainer
//    {
//        // the container is the master factory
//        public static UnityContainer Container = new UnityContainer();

//        // constructor, to configure the bindings
//        static DIContainer()
//        {
//            string chooserType = ConfigurationManager.ConnectionStrings["Dependancy"].ToString();

//            // Tell Unity that IChoiceGetter should resolve to RandomChoice
//            if (chooserType == "SQL")
//            {
//                InjectionProperty injectionProperty =
//                    new InjectionProperty("ChoiceBehavior", new RandomChoice());
//                Container.RegisterType<IBriefcaseRepo>(injectionProperty);
//            }

//            else
//                throw new Exception("Chooser key in app.config not set properly!");
//        }
//    }
//}
