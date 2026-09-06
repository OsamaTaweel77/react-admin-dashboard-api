import { Paper, Stack, Typography, useTheme } from "@mui/material";
import React from "react";
import Card from "./card";
import EmailIcon from "@mui/icons-material/Email";
import PointOfSaleIcon from "@mui/icons-material/PointOfSale";
import PersonAddIcon from "@mui/icons-material/PersonAdd";
import TrafficIcon from "@mui/icons-material/Traffic";
import { data1, data2, data3, data4 } from "./data";

const Row1 = ({ userCount, contactCount, invoiceCount, taskCount }) => {
  const theme = useTheme();
  return (
    <Stack
      direction={"row"}
      flexWrap={"wrap"}
      gap={1}
      justifyContent={{ xs: "center", sm: "space-between" }}
    >
      <Card
        icon={
          <PersonAddIcon
            sx={{ fontSize: "23px", color: theme.palette.secondary.main }}
          />
        }
        title={userCount.toString()}
        subTitle={"Total Users"}
        increase={"+12%"}
        data={data1}
        scheme={"nivo"}
      />

      <Card
        icon={
          <EmailIcon
            sx={{ fontSize: "23px", color: theme.palette.secondary.main }}
          />
        }
        title={contactCount.toString()}
        subTitle={"Total Contacts"}
        increase={"+8%"}
        data={data2}
        scheme={"category10"}
      />

      <Card
        icon={
          <PointOfSaleIcon
            sx={{ fontSize: "23px", color: theme.palette.secondary.main }}
          />
        }
        title={invoiceCount.toString()}
        subTitle={"Total Invoices"}
        increase={"+15%"}
        data={data3}
        scheme={"accent"}
      />

      <Card
        icon={
          <TrafficIcon
            sx={{ fontSize: "23px", color: theme.palette.secondary.main }}
          />
        }
        title={taskCount.toString()}
        subTitle={"Total Tasks"}
        increase={"+5%"}
        data={data4}
        scheme={"dark2"}
      />
    </Stack>
  );
};

export default Row1;
