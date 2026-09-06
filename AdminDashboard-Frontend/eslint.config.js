import js from "@eslint/js";
import globals from "globals";

export default [
  // 1. إعدادات ESLint الأساسية (المستحسنة)
  js.configs.recommended,

  // 2. الإعدادات الخاصة بالمشروع
  {
    files: ["src/**/*.{js,jsx}"],
    languageOptions: {
      ecmaVersion: "latest",
      sourceType: "module",
      globals: {
        ...globals.browser,
        ...globals.node,
        ...globals.es2021,
      },
      parserOptions: {
        ecmaFeatures: {
          jsx: true,
        },
      },
    },
    rules: {
      // تعطيل بعض القواعد التي تسبب مشاكل في المشروع الحالي
      "no-unused-vars": "warn",
      "no-undef": "off", // لأن React يعرفها عبر الاستيراد
      "react/react-in-jsx-scope": "off", // React 17+ لا يحتاجها
      "react/prop-types": "off", // إذا لم تستخدم PropTypes
    },
  },

  // 3. تجاهل بعض الملفات
  {
    ignores: [
      "node_modules/**",
      "dist/**",
      "build/**",
      "*.config.js",
      "*.config.cjs",
    ],
  },
];
