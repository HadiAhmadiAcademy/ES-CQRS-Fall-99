using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ServiceHost.Conventions
{
    public class CqsModelConvention : IApplicationModelConvention
    {
        private const string Query = "QueryController";
        public void Apply(ApplicationModel application)
        {
            var queryControllers = application.Controllers.Where(a =>
                a.ControllerType.Name.EndsWith(Query, StringComparison.OrdinalIgnoreCase));

            foreach (var controller in queryControllers)
            {
                foreach (var selectorModel in controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList())
                {
                    selectorModel.AttributeRouteModel =
                        new AttributeRouteModel
                        {
                            Template = "api/" +
                                       controller.ControllerType.Name.Replace(Query, "", StringComparison.OrdinalIgnoreCase)
                        };
                }
            }
        }
    }
}
