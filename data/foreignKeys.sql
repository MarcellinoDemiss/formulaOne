ALTER TABLE [dbo].[Driver]  WITH CHECK ADD  CONSTRAINT [driver-country] FOREIGN KEY(countryCode)
REFERENCES [dbo].Country ([countryCode])
ON UPDATE CASCADE;