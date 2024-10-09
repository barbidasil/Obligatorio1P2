using System;
using System.Collections.Generic;
using LogicaNegocio;

public class Publicacion
{
    private static int s_ultimoId = 0;

    private int _idP;
    private string _name;
    private DateTime _publishDate;
    private Status _status;
    private List<Article> _articles = new List<Article>();
    private Usuario _buyingUser;
    private Usuario _userFinish;
    private DateTime _publicationEnd;

    public int IdP
    {
        get { return _idP; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public DateTime PublishDate
    {
        get { return _publishDate; }
        set { _publishDate = value; }
    }

    public Status Status
    {
        get { return _status; }
        set { _status = value; }
    }

    public List<Article> Articles
    {
        get { return _articles; }
    }

    public Usuario BuyingUser
    {
        get { return _buyingUser; }
        set { _buyingUser = value; }
    }

    public Usuario UserFinish
    {
        get { return _userFinish; }
        set { _userFinish = value; }
    }

    public DateTime PublicationEnd
    {
        get { return _publicationEnd; }
        set { _publicationEnd = value; }
    }

   

    public Publicacion(string name, DateTime publishDate, Status status, Usuario buyingUser, Usuario userFinish, DateTime publicationEnd)
    {


        s_ultimoId++;
        this._idP = s_ultimoId;
        this._name = name;
        this._publishDate = publishDate;
        this._status = status;
        this._buyingUser = buyingUser;
        this._userFinish = userFinish;
        this._publicationEnd = publicationEnd;
    }

    public override string ToString()
    {
        return this._name;
    }
}

// Clase Sales que hereda de Publicacion
public class Sales : Publicacion
{
    private bool _flashOffer;

    public bool FlashOffer
    {
        get { return _flashOffer; }
        set { _flashOffer = value; }
    }

    public Sales(string name, DateTime publishDate, Status status, Usuario buyingUser, Usuario userFinish, DateTime publicationEnd, bool flashOffer)
        : base(name, publishDate, status, buyingUser, userFinish, publicationEnd)
    {
        this._flashOffer = flashOffer;
    }
}

// Clase Auction que hereda de Publicacion


public class Auction : Publicacion
{
    private List<Offer> _offers = new List<Offer>();

    public List<Offer> Offers
    {
        get { return _offers; }
    }

    public Auction(string name, DateTime publishDate, Status status, Usuario buyingUser, Usuario userFinish, DateTime publicationEnd)
        : base(name, publishDate, status, buyingUser, userFinish, publicationEnd)
    {
    }

    public void AddOffer(Offer offer)
    {
        _offers.Add(offer);
    }
}




