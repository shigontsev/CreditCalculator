using CreditCalculator.BLL.BLL;
using CreditCalculator.BLL.Interfaces;
using CreditCalculator.DAL.Interfaces;
using CreditCalculator.DAL.Server;

namespace CreditCalculator.Dependencies
{
    public class DependencyResolver
    {
        private static DependencyResolver _instance;

        public static DependencyResolver Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new DependencyResolver();
                }
                return _instance;
            }
        }

        private ICreditDAO CreditDAO => new CreditDAO();

        public ICreditLogic CreditLogic => new CreditLogic(CreditDAO);


    }
}