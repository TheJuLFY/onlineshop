import React from 'react';

export class ProductService {
  async getProducts() {
    try {
      const response = await fetch('api/products');
      const productData = await response.json();
      return productData;
    } catch (error) {
      throw Error('Failed to fetch products');
    }
  }
}
