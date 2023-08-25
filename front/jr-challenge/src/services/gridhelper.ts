import React, { useEffect, useState } from "react";
import { Permission } from "./models/Permission";
import  fetchPermissions  from "../services/api";

const usePermissionData = (): [Permission[], () => void] => {
    const [permissionsData, setPermissionsData] = useState<Permission[]>([]);

    const fetchPermissionsData = async () => {
        try {
          const response = await fetchPermissions();
          setPermissionsData(response) ;
        } catch (error) {
          console.error("Error fetching data:", error);
        }
      };
    
      useEffect(() => {
        fetchPermissionsData();
      }, []);
    
      return [permissionsData, fetchPermissionsData];
    };
    
    export default usePermissionData;