import './App.css';
import Grid from "./components/Grid";
import { CssBaseline } from "@mui/material";
import { createTheme, ThemeProvider } from "@mui/material/styles";

const theme = createTheme({
  palette: {
    primary: {
      main: "#1976d2",
    },
    secondary: {
      main: "#f50057",
    },
  },
});

function App() {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <div className="App">
        <h1 style={{ textAlign: "center" }}>Javier Rojas Challenge</h1>
        <Grid />
      </div>
    </ThemeProvider>
  );
}

export default App;
