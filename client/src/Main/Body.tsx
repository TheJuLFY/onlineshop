import Box from '@mui/material/Box';
import React from 'react';

import { ProductList } from 'src/ProductList/ProductList';

export const Body = () => (
  <Box
    sx={{
      marginLeft: '4vw',
      marginRight: '4vw',
    }}
  >
    <ProductList />
  </Box>
);
