﻿namespace Baskets.API.Exceptions;

public class BasketNotFoundException(string userName) : NotFoundException("Basket", userName) { }
