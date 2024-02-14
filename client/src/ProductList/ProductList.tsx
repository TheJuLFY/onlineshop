import React, { Fragment } from 'react';
import { Grid } from '@material-ui/core';

import { ProductService } from 'src/services/ProductService';
import { Product } from 'src/models/Product';

import { ProductCard } from './ProductCard';

type ProductState = {
  error: string;
  items: Product[];
};

export class ProductList extends React.Component<unknown, ProductState> {
  constructor(props: unknown) {
    super(props);
    this.state = {
      error: '',
      items: [],
    };
  }

  async componentDidMount() {
    try {
      const productService = new ProductService();
      const products = await productService.getProducts();
      this.setState({
        items: products,
      });
    } catch (error) {
      this.setState({
        error: 'Sorry, the product list is not avaliable',
        items: [],
      });
    }
  }

  render() {
    const { error, items } = this.state;

    if (error) {
      return error;
    } else {
      return (
        <div>
          <Grid container spacing={4} justifyContent="space-between">
            {items.map(product => (
              <Grid key={product.id} item>
                <ProductCard product={product} />
              </Grid>
            ))}
          </Grid>
        </div>
      );
    }
  }
}
