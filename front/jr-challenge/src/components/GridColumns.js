const columns = [  
    { field: "name", headerName: "Nombre Empleado", width: 200, editable:true },
    { field: "surName", headerName: "Apellido Empleado", width: 200, editable:true },
    { field: "permissionType", headerName: "Tipo Permiso", width: 200, editable:true,
    valueGetter: (params) => params.row.permissionType.description },
    { field: "permissionDate", headerName: "Fecha Permiso", width: 200, editable:true,
    valueGetter: (params) => {
      const date = new Date(params.value);
      const options = { day: "2-digit", month: "2-digit", year: "numeric" };
      return date.toLocaleDateString("es-ES", options);
    }, 
  },
  ];

  export default columns;