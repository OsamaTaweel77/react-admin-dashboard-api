import React, { useState, useEffect } from "react";
import Row1 from "./Row1";
import Row2 from "./Row2";
import Row3 from "./Row3";
import Button from "@mui/material/Button";
import { DownloadOutlined } from "@mui/icons-material";
import { Box, Stack, Typography, useTheme } from "@mui/material";
import Header from "../../components/Header";
import { getTasks, getUsers, getContacts, getInvoices } from "../../services/api";

const Dashboard = () => {
  const theme = useTheme();
  const [taskCount, setTaskCount] = useState(0);
  const [userCount, setUserCount] = useState(0);
  const [contactCount, setContactCount] = useState(0);
  const [invoiceCount, setInvoiceCount] = useState(0);
  const [loading, setLoading] = useState(true);

  // =============================================
  // جلب الإحصائيات من الـ API
  // =============================================
  useEffect(() => {
    loadStats();
  }, []);

  const loadStats = async () => {
    try {
      setLoading(true);
      const [tasks, users, contacts, invoices] = await Promise.all([
        getTasks(),
        getUsers(),
        getContacts(),
        getInvoices(),
      ]);
      setTaskCount(tasks.length);
      setUserCount(users.length);
      setContactCount(contacts.length);
      setInvoiceCount(invoices.length);
    } catch (err) {
      console.error("فشل في تحميل الإحصائيات:", err);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <Stack direction={"row"} justifyContent={"space-between"} alignItems={"center"}>
        <Header
          isDashboard={true}
          title={"DASHBOARD"}
          subTitle={"Welcome to your dashboard"}
        />
        <Box sx={{ textAlign: "right", mb: 1.3 }}>
          <Button
            sx={{ padding: "6px 8px", textTransform: "capitalize" }}
            variant="contained"
            color="primary"
          >
            <DownloadOutlined />
            Download Reports
          </Button>
        </Box>
      </Stack>

      {loading ? (
        <Typography align="center" sx={{ py: 8 }}>
          ⏳ جاري تحميل البيانات...
        </Typography>
      ) : (
        <>
          <Row1 
            userCount={userCount} 
            contactCount={contactCount} 
            invoiceCount={invoiceCount} 
            taskCount={taskCount} 
          />
          <Row2 />
          <Row3 />
        </>
      )}
    </div>
  );
};

export default Dashboard;