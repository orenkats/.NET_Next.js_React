import React from "react";
import Layout from "./components/Layout/Layout";
import RandomUserPage from "./pages/RandomUserPage";

const App: React.FC = () => {
  return (
    <Layout>
      <RandomUserPage /> {/* Include the RandomUserPage */}
    </Layout>
  );
};

export default App;
