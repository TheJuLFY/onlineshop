import * as React from 'react';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Button from '@mui/material/Button';

const pages = ['All', 'Low-tonnage', 'Medium-tonnage', 'Large-tonnage'];

export const Header = () => (
  <Toolbar
    sx={{
      marginLeft: '4vw',
      marginRight: '4vw',
    }}
  >
    <Box
      sx={{
        bgcolor: 'primary.main',
        boxShadow: 3,
        borderRadius: 5,
        p: 1,
      }}
    >
      <Button>
        <Box
          sx={{
            fontFamily: 'monospace',
            color: 'grey.A100',
            fontSize: 30,
            mx: 3,
          }}
        >
          AutoStore
        </Box>
      </Button>
    </Box>

    <Box
      sx={{
        marginLeft: '4vw',
        marginRight: '4vw',
        flexGrow: 1,
      }}
    >
      {pages.map(page => (
        <Button key={page}>
          <Box
            sx={{
              marginLeft: '1vw',
              marginRight: '1vw',
              fontSize: 16,
              color: 'primary.dark',
            }}
          >
            {page}
          </Box>
        </Button>
      ))}
    </Box>
  </Toolbar>
);
