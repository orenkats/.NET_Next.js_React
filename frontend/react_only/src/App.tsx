import React from "react";
import Layout from "./components/Layout";
import UsersPage from "./pages/UsersPage";

const App: React.FC = () => {
  return (
    <Layout>
      <UsersPage /> {/* Include the RandomUserPage */}
    </Layout>
  );
};

export default App;
