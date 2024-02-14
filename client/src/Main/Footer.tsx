import Box from '@material-ui/core/Box';
import React from 'react';

export const Footer = () => (
  <Box
    sx={{
      textAlign: 'right',
      marginLeft: '4vw',
      marginRight: '4vw',
    }}
  >
    <Box
      sx={{
        fontFamily: 'monospace',
        color: 'text.primary',
        fontSize: 18,
        mt: 2,
        mx: 3,
      }}
    >
      Copyright ©2022 AutoStore
    </Box>

    <Box
      sx={{
        fontFamily: 'monospace',
        color: 'text.primary',
        fontSize: 15,
        mt: 0.5,
        mx: 3,
      }}
    >
      Website by Bogdan Kovalyov
    </Box>
  </Box>
);
