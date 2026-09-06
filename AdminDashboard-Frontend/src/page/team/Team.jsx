import React, { useState, useEffect } from "react";
import { DataGrid } from "@mui/x-data-grid";
import { useTheme, Box, Typography } from "@mui/material";
import {
  AdminPanelSettingsOutlined,
  LockOpenOutlined,
  SecurityOutlined,
} from "@mui/icons-material";
import Header from "../../components/Header";
import { getUsers } from "../../services/api";

const Team = () => {
  const theme = useTheme();
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // =============================================
  // جلب المستخدمين من الـ API
  // =============================================
  useEffect(() => {
    loadUsers();
  }, []);

  const loadUsers = async () => {
    try {
      setLoading(true);
      const data = await getUsers();
      setUsers(data);
      setError(null);
    } catch (err) {
      setError("فشل في تحميل المستخدمين: " + err.message);
    } finally {
      setLoading(false);
    }
  };

  // =============================================
  // تعريف أعمدة الجدول
  // =============================================
  const columns = [
    {
      field: "id",
      headerName: "ID",
      width: 33,
      align: "center",
      headerAlign: "center",
    },
    {
      field: "name",
      headerName: "Name",
      flex: 1,
      align: "center",
      headerAlign: "center",
    },
    {
      field: "email",
      headerName: "Email",
      flex: 1,
      align: "center",
      headerAlign: "center",
    },
    {
      field: "age",
      headerName: "Age",
      align: "center",
      headerAlign: "center",
      width: 80,
    },
    {
      field: "phone",
      headerName: "Phone",
      flex: 1,
      align: "center",
      headerAlign: "center",
    },
    {
      field: "access",
      headerName: "Access",
      flex: 1,
      align: "center",
      headerAlign: "center",
      renderCell: ({ row }) => {
        const access = row.access || "User";
        return (
          <Box
            sx={{
              p: "5px",
              width: "99px",
              borderRadius: "3px",
              textAlign: "center",
              display: "flex",
              justifyContent: "space-evenly",
              backgroundColor:
                access === "Admin"
                  ? theme.palette.primary.dark
                  : access === "Manager"
                    ? theme.palette.secondary.dark
                    : "#3da58a",
            }}
          >
            {access === "Admin" && (
              <AdminPanelSettingsOutlined
                sx={{ color: "#fff" }}
                fontSize="small"
              />
            )}
            {access === "Manager" && (
              <SecurityOutlined sx={{ color: "#fff" }} fontSize="small" />
            )}
            {access === "User" && (
              <LockOpenOutlined sx={{ color: "#fff" }} fontSize="small" />
            )}
            <Typography sx={{ fontSize: "13px", color: "#fff" }}>
              {access}
            </Typography>
          </Box>
        );
      },
    },
  ];

  // =============================================
  // عرض الصفحة
  // =============================================
  return (
    <Box>
      <Header title="TEAM" subTitle="Managing the Team Members" />

      {loading ? (
        <Typography align="center" sx={{ py: 4 }}>
          ⏳ جاري تحميل المستخدمين...
        </Typography>
      ) : error ? (
        <Typography align="center" sx={{ py: 4, color: "red" }}>
          ❌ {error}
        </Typography>
      ) : (
        <Box sx={{ height: 600, mx: "auto" }}>
          <DataGrid rows={users} columns={columns} getRowId={(row) => row.id} />
        </Box>
      )}
    </Box>
  );
};

export default Team;
