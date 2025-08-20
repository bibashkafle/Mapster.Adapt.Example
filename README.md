# What is Mapster?
Mapster is a high-performance, convention-based object-to-object mapper for .NET.
It helps you map data between objects — especially when:

- You have separate domain models, DTOs (Data Transfer Objects), and view models.
- You don’t want to write repetitive obj.Property = otherObj.Property; code.

# Why Use It? (Daily Challenges It Solves)
1. Avoid Repetitive Boilerplate Mapping
2. Decouple Layers
   - You often don’t want your Entity Framework entities going directly to API clients.
   - Mapster helps transform them into DTOs or view models easily.
  
3. Complex Mapping with Custom Rules\
   You can define:
  - Ignore certain properties
  - Rename mappings
  - Flatten/nest objects
  - Combine properties
    
4. Performance Concerns\
   Mapster can pre-compile mappings, avoiding reflection overhead in production.

Benefits in Day-to-Day Work

✅ No more repetitive mapping code\
✅ Easy to maintain and change mapping rules in one place\
✅ Safer data exposure (exclude sensitive fields)\
✅ Performance-optimized for high-traffic APIs\
✅ Works great with CQRS or Clean Architecture where DTO ↔ Entity mapping is constant\
