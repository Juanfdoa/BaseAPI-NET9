-- Script Name: 002.add_client_types_table.sql
-- Script author: Juan Acevedo
-- Script date: 06/07/2026

-- Check if the column doesn't exist, and if so, add it
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM information_schema.tables
        WHERE table_schema = 'public'
          AND table_name = 'client_types'
    ) THEN

        CREATE TABLE public.client_types
        (
            id UUID PRIMARY KEY,

            name VARCHAR(100) NOT NULL,
            description VARCHAR(300),

            is_active BOOLEAN NOT NULL DEFAULT TRUE,

            created_at TIMESTAMP WITHOUT TIME ZONE NOT NULL,
            updated_at TIMESTAMP WITHOUT TIME ZONE,
            deleted_at TIMESTAMP WITHOUT TIME ZONE
        );

    END IF;
END $$;

-- Initial data
INSERT INTO public.client_types (id, name, description, is_active, created_at)
SELECT gen_random_uuid(), 'Hospital', 'Hospital', TRUE, NOW()
WHERE NOT EXISTS (SELECT 1 FROM public.client_types WHERE name = 'Hospital');

INSERT INTO public.client_types (id, name, description, is_active, created_at)
SELECT gen_random_uuid(), 'Clinic', 'Clinic', TRUE, NOW()
WHERE NOT EXISTS (SELECT 1 FROM public.client_types WHERE name = 'Clinic');

INSERT INTO public.client_types (id, name, description, is_active, created_at)
SELECT gen_random_uuid(), 'IPS', 'Health Service Provider Institution', TRUE, NOW()
WHERE NOT EXISTS (SELECT 1 FROM public.client_types WHERE name = 'IPS');

INSERT INTO public.client_types (id, name, description, is_active, created_at)
SELECT gen_random_uuid(), 'Laboratory', 'Clinical Laboratory', TRUE, NOW()
WHERE NOT EXISTS (SELECT 1 FROM public.client_types WHERE name = 'Laboratory');

INSERT INTO public.client_types (id, name, description, is_active, created_at)
SELECT gen_random_uuid(), 'Medical Center', 'Medical Center', TRUE, NOW()
WHERE NOT EXISTS (SELECT 1 FROM public.client_types WHERE name = 'Medical Center');

INSERT INTO public.client_types (id, name, description, is_active, created_at)
SELECT gen_random_uuid(), 'Other', 'Other', TRUE, NOW()
WHERE NOT EXISTS (SELECT 1 FROM public.client_types WHERE name = 'Other');