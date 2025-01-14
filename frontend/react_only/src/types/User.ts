export interface User {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  dateOfBirth: string;
  phone: string;
  address: string;
  profilePicture: string;
}

export interface UserResponse {
  results: User[];
  info: {
    totalCount: number; // Updated for backend response
    page: number;
    pageSize: number;
  };
}
