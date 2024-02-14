import React from 'react';
import { ThemeProvider } from 'styled-components';
import { createTheme } from '@material-ui/core/styles';

import { Body } from './Main/Body';
import { Footer } from './Main/Footer';
import { Header } from './Main/Header';

const theme = createTheme({});

export const App = () => (
  <ThemeProvider theme={theme}>
    <Header />
    <br />
    <Body />
    <br />
    <Footer />
  </ThemeProvider>
);
