﻿using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services;

public class SellerService
{
    private readonly SalesWebMVCContext _context;

    public SellerService(SalesWebMVCContext context)
    {
        _context = context;
    }

    public List<Seller> FindAll()
    {
        return _context.Seller.ToList();
    }

    public void Insert(Seller obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public Seller FindById(int id)
    {
        return _context.Seller.FirstOrDefault(sel => sel.Id == id);
    }

    public void DeleteById(int id)
    {
        var obj = _context.Seller.Find(id);
        _context.Remove(obj);
        _context.SaveChanges();
    }
}
