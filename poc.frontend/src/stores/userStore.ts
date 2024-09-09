import { Session, User } from "@supabase/supabase-js";
import { create } from "zustand";

export interface UserState {
    user: User | null;
    session: Session | null;
    permission: number | null;
    setUser: (user: User | null) => void;
    setSession: (session: Session | null) => void;
    setPermission: (permission: number | null) => void;
}

const userStore = create<UserState>((set) => ({
    user: null,
    session: null,
    permission: null,
    setUser: (user: User | null) => set({ user }),
    setSession: (session: Session | null) => set({ session: session }),
    setPermission: (permission: number | null) => set({ permission: permission }),
}));

export default userStore;