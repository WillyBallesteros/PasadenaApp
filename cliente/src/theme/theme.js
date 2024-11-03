import { createMuiTheme } from '@material-ui/core/styles';

const theme = createMuiTheme({
  palette: {
      light: "#f8f8f8",
      main: "#1976d2",
      dark : "#004da0",
      contrastText: "#ecfad8"
  },
  overrides: {
    MuiToolbar: {
      regular: {
        backgroundColor: "#f8f8f8",
        color: "#666",
        height: "33px",
        minHeight: "33px",
        '@media(min-width:600px)' : {
          minHeight:"33px"
        }
      }
    },
    MuiAvatar: {
      root: {
        width:"33px",
        height: "33px"
      }
    }
  }

});



export default theme;