import React, { useState, useEffect } from "react";
import { DataGrid, GridToolbar } from "@mui/x-data-grid";
import { Box, Typography, Chip } from "@mui/material";
import Header from "../../components/Header";
import { getTasks } from "../../services/api";

const Tasks = () => {
  const [tasks, setTasks] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    loadTasks();
  }, []);

  const loadTasks = async () => {
    try {
      setLoading(true);
      const data = await getTasks();
      setTasks(data);
      setError(null);
    } catch (err) {
      setError("Failed to load tasks: " + err.message);
    } finally {
      setLoading(false);
    }
  };

  const getStatusInfo = (status) => {
    const statusMap = {
      0: { label: "New", color: "info" },
      1: { label: "In Progress", color: "warning" },
      2: { label: "Completed", color: "success" },
    };
    return statusMap[status] || { label: "Unknown", color: "default" };
  };

  const columns = [
    { field: "id", headerName: "ID", width: 50 },
    {
      field: "title",
      headerName: "Title",
      flex: 1,
    },
    {
      field: "description",
      headerName: "Description",
      flex: 1.5,
    },
    {
      field: "status",
      headerName: "Status",
      width: 130,
      renderCell: ({ row }) => {
        const status = getStatusInfo(row.status);
        return <Chip label={status.label} color={status.color} size="small" />;
      },
    },
    {
      field: "createdAt",
      headerName: "Created Date",
      width: 130,
      renderCell: ({ row }) => {
        return new Date(row.createdAt).toLocaleDateString("en-US", {
          year: "numeric",
          month: "short",
          day: "numeric",
        });
      },
    },
    {
      field: "dueDate",
      headerName: "Due Date",
      width: 130,
      renderCell: ({ row }) => {
        if (!row.dueDate) return "-";
        return new Date(row.dueDate).toLocaleDateString("en-US", {
          year: "numeric",
          month: "short",
          day: "numeric",
        });
      },
    },
  ];

  return (
    <Box>
      <Header title="TASKS" subTitle="List of All Tasks" />

      {loading ? (
        <Typography align="center" sx={{ py: 4 }}>
          ⏳ Loading tasks...
        </Typography>
      ) : error ? (
        <Typography align="center" sx={{ py: 4, color: "red" }}>
          ❌ {error}
        </Typography>
      ) : (
        <Box sx={{ height: 600, mx: "auto" }}>
          <DataGrid
            slots={{
              toolbar: GridToolbar,
            }}
            rows={tasks}
            columns={columns}
            getRowId={(row) => row.id}
          />
        </Box>
      )}
    </Box>
  );
};

export default Tasks;
