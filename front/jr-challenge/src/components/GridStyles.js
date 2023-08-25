import { makeStyles } from '@mui/styles';
const useStyles = makeStyles((theme) => ({
    gridContainer: {
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        width: "100%",
    },
    gridContent: {
        display: "flex",
        flexDirection: "column",
        alignItems: "center", 
      },
  }));

  export default useStyles;