// =====================================================
// ملف: services/api.js
// الوظيفة: إدارة الاتصال مع الـ API الخلفي (Backend)
// =====================================================

import axios from "axios";

// =============================================
// عنوان الـ API (يجب أن يتطابق مع المنفذ في Backend)
// =============================================
const API_BASE_URL = "https://localhost:7169/api";

// =============================================
// إنشاء كائن Axios مع الإعدادات الأساسية
// =============================================
const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

// =============================================
// دوال الاتصال بالـ API
// =============================================

// 1. جلب جميع المستخدمين (Users)
export const getUsers = async () => {
  const response = await api.get("/Users");
  return response.data;
};

// 2. جلب مستخدم حسب ID
export const getUserById = async (id) => {
  const response = await api.get(`/Users/${id}`);
  return response.data;
};

// 3. جلب جميع جهات الاتصال (Contacts)
export const getContacts = async () => {
  const response = await api.get("/Contacts");
  return response.data;
};

// 4. جلب جهة اتصال حسب ID
export const getContactById = async (id) => {
  const response = await api.get(`/Contacts/${id}`);
  return response.data;
};

// 5. جلب جميع الفواتير (Invoices)
export const getInvoices = async () => {
  const response = await api.get("/Invoices");
  return response.data;
};

// 6. جلب فاتورة حسب ID
export const getInvoiceById = async (id) => {
  const response = await api.get(`/Invoices/${id}`);
  return response.data;
};

// 7. جلب جميع المهام (Tasks)
export const getTasks = async () => {
  const response = await api.get("/Tasks");
  return response.data;
};

// 8. جلب مهمة حسب ID
export const getTaskById = async (id) => {
  const response = await api.get(`/Tasks/${id}`);
  return response.data;
};

export default api;
