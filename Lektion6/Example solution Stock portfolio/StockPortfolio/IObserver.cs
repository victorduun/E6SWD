﻿namespace StockPortfolio
{
    public interface IObserver<T>
    {
        void Update(T subject);
    }
}
