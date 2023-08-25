import React, { useEffect, useState } from "react";
import { DataGrid } from "@mui/x-data-grid";
import mockData from "../data/mockData";
import columns from "./GridColumns";
import useStyles from "./GridStyles";
import usePermissionData  from "../services/gridhelper";

function Grid() {
  const classes = useStyles();
  const [permissionsData, fetchPermissionsData] = usePermissionData();
  useEffect(() => {
    fetchPermissionsData();
  }, []);

  return (
    <div className={classes.gridContainer}>
     <div className={classes.gridContent}>
    <DataGrid 
      rows={permissionsData} 
    //rows={mockData}
      columns={columns} 
      style={{ width: "100%" }} 
      />
        {!permissionsData.length??       
          <div>No se pudo obtener datos</div>
        }
      </div>
    </div>
  );
}

export default Grid;