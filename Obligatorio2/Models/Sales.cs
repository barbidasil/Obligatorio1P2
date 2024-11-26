using Obligatorio2.Models;

public class Sales : Publicacion
{
    public bool FlashOffer { get; set; }
    public List<Article> Articles { get; set; } = new List<Article>();

    public override decimal GetPrice()
    {
        decimal totalPrice = 0;
        foreach (Article article in Articles)
        {
            totalPrice += article.SellPrice;
        }
        return FlashOffer ? totalPrice * 0.8m : totalPrice;
    }
}
