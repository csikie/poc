import userStore from '@/stores/userStore';
import axios from 'axios';
import { useEffect, useState } from 'react';

export type User = {
  userId: string;
  email: string;
  roles: string[];
}

const useUsers = () => {
  const [data, setData] = useState<User[]>([]);
  const session = userStore((state) => state.session);

  useEffect(() => {
    if (!session?.access_token) return;
    axios
      .get(`${import.meta.env.VITE_SUPABASE_NET_API_URL}/user`, {
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${session?.access_token}`,
        },
      })
      .then((response) => setData(response.data));
  }, [session?.access_token]);

  return {
    data,
  };
};

export default useUsers;
