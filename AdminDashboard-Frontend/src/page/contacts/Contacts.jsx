import React, { useState, useEffect } from "react";
import { DataGrid, GridToolbar } from "@mui/x-data-grid";
import { Box, Typography } from "@mui/material";
import Header from "../../components/Header";
import { getContacts } from "../../services/api";

const Contacts = () => {
  const [contacts, setContacts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // =============================================
  // جلب جهات الاتصال من الـ API
  // =============================================
  useEffect(() => {
    loadContacts();
  }, []);

  const loadContacts = async () => {
    try {
      setLoading(true);
      const data = await getContacts();
      setContacts(data);
      setError(null);
    } catch (err) {
      setError("فشل في تحميل جهات الاتصال: " + err.message);
    } finally {
      setLoading(false);
    }
  };

  // =============================================
  // تعريف أعمدة الجدول
  // =============================================
  const columns = [
    { field: "id", headerName: "ID", width: 33 },
    { field: "registrarId", headerName: "Registrar ID", width: 120 },
    {
      field: "name",
      headerName: "Name",
      flex: 1,
      cellClassName: "name-column--cell",
    },
    {
      field: "age",
      headerName: "Age",
      type: "number",
      headerAlign: "left",
      align: "left",
      width: 60,
    },
    {
      field: "phone",
      headerName: "Phone Number",
      flex: 1,
    },
    {
      field: "email",
      headerName: "Email",
      flex: 1,
    },
    {
      field: "address",
      headerName: "Address",
      flex: 1,
    },
    {
      field: "city",
      headerName: "City",
      flex: 1,
    },
    {
      field: "zipCode",
      headerName: "Zip Code",
      width: 100,
    },
  ];

  // =============================================
  // عرض الصفحة
  // =============================================
  return (
    <Box>
      <Header
        title="CONTACTS"
        subTitle="List of Contacts for Future Reference"
      />

      {loading ? (
        <Typography align="center" sx={{ py: 4 }}>
          ⏳ جاري تحميل جهات الاتصال...
        </Typography>
      ) : error ? (
        <Typography align="center" sx={{ py: 4, color: "red" }}>
          ❌ {error}
        </Typography>
      ) : (
        <Box sx={{ height: 650, width: "99%", mx: "auto" }}>
          <DataGrid
            slots={{
              toolbar: GridToolbar,
            }}
            rows={contacts}
            columns={columns}
            getRowId={(row) => row.id}
          />
        </Box>
      )}
    </Box>
  );
};

export default Contacts;
