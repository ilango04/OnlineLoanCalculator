using OnlineLoanCalculator_DAL;
using OnlineLoanCalculator_EL;
using System.Web.UI.WebControls;
namespace OnlineLoanCalculator_BL
{
    public class CustomerBL
    {
        CustomerRepository customerRepository = new CustomerRepository();
        public bool DisplayCustomerDetails(GridView gridViewId)
        {
           return customerRepository.DisplayDetails(gridViewId);
        }
        public bool DeleteCustomer(int customerId)
        {
           return customerRepository.DeleteCustomerDetails(customerId);

        }
        public bool UpdateCustomer(Customer customer,int id)
        {
           return customerRepository.UpdateCustomerDetails(customer, id);
        }
        public bool AddCustomer(Customer customer)
        {
           return customerRepository.AddCustomerDetails(customer);
        }
    }
}
