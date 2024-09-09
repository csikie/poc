import userStore from "@/stores/userStore";
import axios from "axios";
import { useEffect, useState } from "react";

export type Role = {
    id: number;
    name: string;
    permissions: number;
};

const useRoles = () => {
    const [data, setData] = useState<Role[]>([]);
    const session = userStore((state) => state.session);

    useEffect(() => {
        if (!session?.access_token) return;
        axios
        .get(`${import.meta.env.VITE_SUPABASE_NET_API_URL}/role`, {
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

export default useRoles;