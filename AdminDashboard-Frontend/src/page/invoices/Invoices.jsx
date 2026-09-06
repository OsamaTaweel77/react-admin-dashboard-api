import React, { useState, useEffect } from "react";
import { DataGrid, GridToolbar } from "@mui/x-data-grid";
import { Box, Typography } from "@mui/material";
import Header from "../../components/Header";
import { getInvoices } from "../../services/api";

const Invoices = () => {
  const [invoices, setInvoices] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // =============================================
  // جلب الفواتير من الـ API
  // =============================================
  useEffect(() => {
    loadInvoices();
  }, []);

  const loadInvoices = async () => {
    try {
      setLoading(true);
      const data = await getInvoices();
      setInvoices(data);
      setError(null);
    } catch (err) {
      setError("فشل في تحميل الفواتير: " + err.message);
    } finally {
      setLoading(false);
    }
  };

  // =============================================
  // تعريف أعمدة الجدول
  // =============================================
  const columns = [
    { field: "id", headerName: "ID", width: 33 },
    {
      field: "name",
      headerName: "Name",
      flex: 1,
    },
    {
      field: "email",
      headerName: "Email",
      flex: 1,
    },
    {
      field: "phone",
      headerName: "Phone Number",
      flex: 1,
    },
    {
      field: "cost",
      headerName: "Cost",
      type: "number",
      flex: 0.5,
      renderCell: ({ row }) => `$${row.cost?.toFixed(2) || 0}`,
    },
    {
      field: "date",
      headerName: "Date",
      flex: 0.5,
      renderCell: ({ row }) => {
        if (!row.date) return "-";
        return new Date(row.date).toLocaleDateString("en-US", {
          year: "numeric",
          month: "long",
          day: "numeric",
        });
      },
    },
  ];

  // =============================================
  // عرض الصفحة
  // =============================================
  return (
    <Box>
      <Header title="INVOICES" subTitle="List of Invoice Balances" />

      {loading ? (
        <Typography align="center" sx={{ py: 4 }}>
          ⏳ جاري تحميل الفواتير...
        </Typography>
      ) : error ? (
        <Typography align="center" sx={{ py: 4, color: "red" }}>
          ❌ {error}
        </Typography>
      ) : (
        <Box sx={{ height: 650, mx: "auto" }}>
          <DataGrid
            checkboxSelection
            slots={{
              toolbar: GridToolbar,
            }}
            rows={invoices}
            columns={columns}
            getRowId={(row) => row.id}
          />
        </Box>
      )}
    </Box>
  );
};

export default Invoices;
