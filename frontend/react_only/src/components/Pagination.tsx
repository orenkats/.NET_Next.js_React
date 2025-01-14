import React from "react";
import styles from "./pagination.module.scss";

interface PaginationProps {
  currentPage: number;
  totalPages: number;
  onPageChange: (page: number) => void;
}

const Pagination: React.FC<PaginationProps> = ({ currentPage, totalPages, onPageChange }) => {
  const pages = Array.from({ length: totalPages }, (_, i) => i + 1); // Generate an array of page numbers

  // Helper to get the button class based on state
  const getButtonClass = (isActive: boolean, isDisabled: boolean) => {
    if (isDisabled) return `${styles.paginationButton} ${styles.paginationButtonDisabled}`;
    if (isActive) return `${styles.paginationButton} ${styles.paginationButtonActive}`;
    return styles.paginationButton;
  };

  // Render a page button
  const renderPageButton = (page: number) => (
    <li key={page}>
      <button
        onClick={() => onPageChange(page)}
        className={getButtonClass(page === currentPage, false)}
      >
        {page}
      </button>
    </li>
  );

  // Render the Previous and Next buttons
  const renderPreviousButton = () => (
    <li>
      <button
        onClick={() => onPageChange(currentPage - 1)}
        disabled={currentPage === 1}
        className={getButtonClass(false, currentPage === 1)}
      >
        Previous
      </button>
    </li>
  );

  const renderNextButton = () => (
    <li>
      <button
        onClick={() => onPageChange(currentPage + 1)}
        disabled={currentPage === totalPages}
        className={getButtonClass(false, currentPage === totalPages)}
      >
        Next
      </button>
    </li>
  );

  return (
    <nav className={styles.paginationContainer}>
      <ul className={styles.paginationList}>
        {renderPreviousButton()}
        {pages.map(renderPageButton)}
        {renderNextButton()}
      </ul>
    </nav>
  );
};

export default Pagination;
