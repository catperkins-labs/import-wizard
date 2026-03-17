/**
 * API client base configuration.
 *
 * The API base URL is set via the VITE_API_URL environment variable.
 * Create a .env.local file in the web/ directory with:
 *   VITE_API_URL=http://localhost:5000
 */
const API_BASE_URL = import.meta.env.VITE_API_URL ?? "http://localhost:5000";

export async function apiFetch<T>(
  path: string,
  options?: RequestInit
): Promise<T> {
  const response = await fetch(`${API_BASE_URL}${path}`, {
    headers: {
      "Content-Type": "application/json",
      ...options?.headers,
    },
    ...options,
  });

  if (!response.ok) {
    const text = await response.text();
    throw new Error(`API error ${response.status}: ${text}`);
  }

  return response.json() as Promise<T>;
}

export { API_BASE_URL };
