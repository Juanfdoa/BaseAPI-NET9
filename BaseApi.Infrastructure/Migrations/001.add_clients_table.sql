-- Script Name: 001.add_clients_table.sql
-- Script author: Juan Acevedo
-- Script date: 06/07/2026

-- Check if the column doesn't exist, and if so, add it
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM information_schema.tables
        WHERE table_schema = 'public'
          AND table_name = 'clients'
    ) THEN

        CREATE TABLE public.clients
        (
            id UUID PRIMARY KEY,

            -- General information
            code VARCHAR(50),
            name VARCHAR(200) NOT NULL,
            legal_name VARCHAR(300),
            tax_id VARCHAR(30) NOT NULL,

            client_type_id UUID NOT NULL,

            -- Contact information
            contact_name VARCHAR(200),
            contact_email VARCHAR(200),
            contact_phone VARCHAR(30),

            email VARCHAR(200),
            phone VARCHAR(30),
            website VARCHAR(250),

            -- Address
            address VARCHAR(300),
            city VARCHAR(100),
            region VARCHAR(100),
            country VARCHAR(100),
            postal_code VARCHAR(20),

            -- Additional information
            notes TEXT,

            -- Status
            is_active BOOLEAN NOT NULL DEFAULT TRUE,

            -- Audit
            created_at TIMESTAMP WITHOUT TIME ZONE NOT NULL,
            updated_at TIMESTAMP WITHOUT TIME ZONE,
            deleted_at TIMESTAMP WITHOUT TIME ZONE,

            CONSTRAINT fk_clients_client_types
                FOREIGN KEY (client_type_id)
                REFERENCES public.client_types(id)
        );

    END IF;
END $$;