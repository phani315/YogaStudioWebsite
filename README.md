# Yoga Studio Website

## Overview
The **Yoga Studio Website** is an integrated software solution designed to enhance the efficiency of managing yoga classes, client reservations, and overall studio operations. This system minimizes manual errors, ensures seamless customer experiences, and provides a scalable, high-availability platform.

---

## **System Architecture**
### **Frontend**
- **Technology Stack:** ASP.NET Core MVC with Razor Views for server-side rendering.
- **JavaScript Integration:** Custom JavaScript with jQuery for dynamic UI interactions.
- **Styling:** Bootstrap for responsive design.
- **State Management:** Minimal client-side state; managed via server-side rendering.
- **Authentication:** Cookie-based authentication with ASP.NET Identity.
- **Performance Optimization:** Server-side caching and AJAX for dynamic updates.

### **Backend**
- **Framework:** .NET 8.0 with ASP.NET Core for RESTful API services.
- **Database:** MySQL with Entity Framework Core for ORM-based data management.
- **Caching:** Redis for session management and query optimization.
- **Security:** HTTPS, CORS, input validation, and OWASP security best practices.

### **Infrastructure & Deployment**
- **Cloud Provider:** AWS (Amazon Web Services)
- **Hosting Services:** EC2 instances for backend, S3 + CloudFront for frontend assets.
- **Containerization:** Dockerized microservices orchestrated by Kubernetes (EKS).
- **CI/CD:** Automated builds, testing, and deployment using GitHub Actions.

---

## **Development Methodologies**
### **Software Development Lifecycle (SDLC)**
- **Hybrid Agile-Waterfall Model:**
  - **Waterfall Approach** for requirement gathering and architectural design.
  - **Agile (Scrum)** for iterative development and continuous feedback.
- **Version Control & Branching Strategy:**
  - GitHub Flow with feature, bugfix, and release branches.
  - Code reviews and PR approvals are mandatory before merging.

---

## **DevOps Methodologies**
### **Infrastructure as Code (IaC)**
- Terraform for provisioning AWS resources and automating deployments.
- Kubernetes manifests and Helm charts for managing application workloads.

### **Continuous Integration & Deployment (CI/CD)**
- **CI:**
  - Linting and static code analysis with SonarQube.
  - Automated unit tests with xUnit for .NET 8.0.
  - Build artifacts stored in AWS S3.
- **CD:**
  - Blue-Green Deployments to minimize downtime.
  - Canary Releases to test new features with a subset of users.

### **Monitoring & Logging**
- **Observability Stack:**
  - **Monitoring:** Prometheus + Grafana for real-time metrics.
  - **Logging:** Centralized logging with ELK (Elasticsearch, Logstash, Kibana).
  - **Tracing:** OpenTelemetry for distributed tracing.
- **Automated Alerts:**
  - Configured via Prometheus Alertmanager & AWS CloudWatch.
  - Slack & PagerDuty notifications for critical incidents.

---

## **Incident Management**
- **Incident Response Plan:** Defined escalation procedures with RACI matrix.
- **Runbooks & Playbooks:** Standard operating procedures for resolving common issues.
- **Postmortem Analysis:** Every major incident is documented and analyzed for future prevention.
- **Disaster Recovery:**
  - Daily database backups with AWS RDS.
  - Multi-AZ deployment to ensure high availability.
  - Failover mechanisms to handle unexpected failures.

---

## **Service Level Agreements (SLAs), Objectives (SLOs), and Indicators (SLIs)**
### **Service Level Agreement (SLA):**
- 99.9% uptime guarantee (~43 minutes downtime per month).
- Response time commitments for customer support inquiries.

### **Service Level Objectives (SLOs):**
- API response time < 200ms.
- Database query latency < 100ms.
- 99.99% success rate for booking transactions.

### **Service Level Indicators (SLIs):**
- **Availability:** API uptime monitored via CloudWatch & Prometheus.
- **Latency:** Response times tracked via Datadog.
- **Error Rates:** 4xx/5xx error tracking through Kibana dashboards.
- **Customer Satisfaction:** CSAT surveys & NPS scores for usability insights.

---

## **Key Features**
- **Class Scheduling & Booking:** Customers can register, browse, and book classes.
- **Automated Waiting List:** Customers get notified when a spot opens up.
- **Admin Dashboard:** Role-based access control for studio management.
- **Real-time Notifications:** Email/SMS alerts for bookings, cancellations, and reminders.
- **Payment Integration:** Stripe & PayPal support for seamless transactions.

---

## **Deployment Instructions**
1. Clone the repository:
   ```sh
   git clone https://github.com/phani315/YogaStudioWebsite.git
   ```
2. Set up environment variables:
   ```sh
   cp .env.example .env
   ```
3. Install dependencies:
   ```sh
   dotnet restore
   ```
4. Build the project:
   ```sh
   dotnet build
   ```
5. Start the development server:
   ```sh
   dotnet run
   ```

---

## **Contribution Guidelines**
- Follow the **Git branching strategy** (`feature/`, `bugfix/`, `hotfix/` branches).
- Code should comply with **C# coding standards and SonarQube analysis**.
- Raise PRs with detailed descriptions and request reviews before merging.

---

## **License**
This project is licensed under the MIT License.

---
