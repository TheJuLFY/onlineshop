import { Button, CardActions, CardContent, makeStyles, Typography } from '@material-ui/core';
import Box from '@mui/material/Box';
import React, { Fragment } from 'react';

import { Product } from 'src/models/Product';

type ProductProp = {
  product: Product;
};

function currencyFormat(num: number) {
  return `$${num.toFixed(0).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')}`;
}

const useStyles = makeStyles({
  multiLineEllipsis: {
    fontFamily: 'Roboto Serif',
    color: 'text.primary',
    fontSize: 14,

    overflow: 'hidden',
    textOverflow: 'ellipsis',
    display: '-webkit-box',
    '-webkit-line-clamp': 3,
    '-webkit-box-orient': 'vertical',
  },
});

export const ProductCard = (props: ProductProp) => {
  const classes = useStyles();

  return (
    <Box
      sx={{
        bgcolor: 'grey.200',
        width: 320,
        boxShadow: 3,
        borderRadius: 3,
      }}
    >
      <Box
        component="img"
        sx={{
          borderRadius: 2,
          width: 320,
        }}
        alt={props.product.name}
        src={props.product.imageUrl}
      />

      <CardContent>
        <Box
          sx={{
            fontFamily: 'monospace',
            color: 'primary.dark',
            fontSize: 21,
            mx: 1,
            mt: 1,
          }}
        >
          {props.product.name}
        </Box>

        <Box
          sx={{
            mx: 1,
            mt: 2,
          }}
        >
          <Typography className={classes.multiLineEllipsis}>{props.product.description}</Typography>
        </Box>

        <Box
          sx={{
            fontFamily: 'monospace',
            color: 'primary.dark',
            fontSize: 23,
            mx: 1,
            mt: 3,
          }}
        >
          {currencyFormat(props.product.price / 70)}
        </Box>
      </CardContent>

      <CardActions>
        <Box
          sx={{
            bgcolor: 'grey.50',
            boxShadow: 3,
            borderRadius: 2,
          }}
        >
          <Button>
            <Box
              sx={{
                fontFamily: 'monospace',
                fontSize: 15,
                color: 'primary.dark',
              }}
            >
              Learn More
            </Box>
          </Button>
        </Box>
      </CardActions>
    </Box>
  );
};
