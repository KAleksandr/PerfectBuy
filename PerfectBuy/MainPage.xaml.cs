namespace PerfectBuy;

public partial class MainPage : ContentPage
{
	decimal bill;
	int tip;
	int noPersons = 1;

	public MainPage()
	{
		InitializeComponent();
	}

    private void txtBill_Completed(object sender, EventArgs e)
    {
		bill = decimal.Parse(txtBill.Text);
		CalculateTotal();
    }

    private void CalculateTotal()
    {
        //Total tip
        var totalTip = (bill * tip) / 100;
        //Tip by person
        var tipByPerson = (totalTip / noPersons);
        lblTipByPerson.Text = $"{tipByPerson:C}";
        //SubTotall
        var subTotal = (bill / noPersons);
        lblSubtotal.Text = $"{subTotal:C}";
        //Total
        var totalByPerson = (bill + totalTip) / noPersons;
        lblTotal.Text = $"{totalByPerson:C}";

    }

    private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        tip = (int)sldTip.Value;
        lblTip.Text = $"Tip: {tip}%";
        CalculateTotal(); 
    }

    private void Btn_Clicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            var btn = (Button)sender;
            var percentage = int.Parse(btn.Text.Replace("%", ""));
            sldTip.Value = percentage;
            
        }
    }

    private void BtnPlusMinus_Clicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            var btn = (Button)sender;
            
            if (btn.Text.Equals("-") && noPersons >1)
            {
                noPersons--;
                
            }
            else if (btn.Text.Equals("+"))
            {
                noPersons++;
            }
            lblNoPersons.Text = noPersons.ToString();
            CalculateTotal();
        }
    }
}

