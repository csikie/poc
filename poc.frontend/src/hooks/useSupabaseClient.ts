
import { createClient as create } from "@supabase/supabase-js"

const useSupabaseClient = () => {
    const client = create(import.meta.env.VITE_SUPABASE_URL, import.meta.env.VITE_SUPABASE_ANON_KEY);

    return client;
};

export default useSupabaseClient;